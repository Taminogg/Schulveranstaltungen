import {Injectable} from '@angular/core';
import {Configuration as BackendConfiguration} from "../backend";
import {Configuration as SecureBackendConfiguration} from "../secureBackend";
import {AuthService} from "./auth.service";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class BackendConfigurationService {
  private config: BackendConfiguration = new BackendConfiguration();

  constructor(private authService: AuthService) {
  }

  async init(): Promise<void> {
    const token = await this.authService.getToken();
    this.config = new BackendConfiguration({
      credentials: {
        'Bearer': token
      },
      basePath: environment.backend
    });
  }

  getConfig(): BackendConfiguration {
    return this.config;
  }
}

@Injectable({
  providedIn: 'root'
})
export class SecureBackendConfigurationService {
  private config: SecureBackendConfiguration = new SecureBackendConfiguration();

  constructor(private authService: AuthService) {
  }

  async init(): Promise<void> {
    const token = await this.authService.getToken();
    this.config = new SecureBackendConfiguration({
      credentials: {
        'Bearer': token
      },
      basePath: environment.secureBackend
    });
  }

  getConfig(): SecureBackendConfiguration {
    return this.config;
  }
}
