import {Component, OnInit} from '@angular/core';
import {SampleService} from "./backend";
import {switchMap, tap} from "rxjs";
import {environment} from "../environments/environment";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  withoutAuth: boolean = false;
  withAuth: boolean = false;

  constructor(private sampleService: SampleService) {
  }

  ngOnInit(): void {
    this.printDisclaimer();
    this.callRequests();
  }

  getClass(value: boolean): string {
    return value ? 'success' : 'error';
  }

  private printDisclaimer() {
    console.log('-'.repeat(100));
    console.info('You\'re running the plugin-template!');
    console.info('It is just a sample, to show how to use the backend API. Feel free to remove it.');
    console.info(`If you start the BackendDev-Server, it is available at ${environment.backendUrl}/swagger/index.html`);
    console.info('If you have implemented new Endpoints, just call the `generateBackend` npm-script in package.json');
    console.log('-'.repeat(100));
  }

  private callRequests() {
    this.sampleService.sampleAuthorizeTestGet().pipe(
      tap(() => this.withoutAuth = true),
      switchMap(_ => this.sampleService.sampleAuthorizeTestGet()),
      tap(() => this.withAuth = true)
    ).subscribe();
  }
}
