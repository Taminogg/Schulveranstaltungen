import {APP_INITIALIZER, NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppComponent} from './app.component';
import {ApiModule as BackendApiModule, Configuration as BackendConfiguration} from './backend';
import {ApiModule as SecureBackendApiModule, Configuration as SecureBackendConfiguration} from './secureBackend';
import {HttpClientModule} from '@angular/common/http';
import {BackendConfigurationService, SecureBackendConfigurationService} from "./core/configuration.service";

export function initConfig(backendConfigService: BackendConfigurationService, secureBackendConfigService: SecureBackendConfigurationService): () => Promise<void> {
  return async () => {
    await backendConfigService.init();
    await secureBackendConfigService.init();
  };
}

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, BackendApiModule, SecureBackendApiModule, HttpClientModule],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: initConfig,
      deps: [BackendConfigurationService, SecureBackendConfigurationService],
      multi: true
    },
    {
      provide: BackendConfiguration,
      useFactory: (configService: BackendConfigurationService) => configService.getConfig(),
      deps: [BackendConfigurationService],
      multi: false
    },
    {
      provide: SecureBackendConfiguration,
      useFactory: (configService: SecureBackendConfigurationService) => configService.getConfig(),
      deps: [SecureBackendConfigurationService],
      multi: false
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
}
