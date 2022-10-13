import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/AppComponente/app.module';
import { environment } from './environments/environment';

export function getBaseUrl() {
  //return environment.baseURL;
  return 'http://beta.backendministerio.com:5002';
}

const providers = [{ provide: 'BASE_URL', useValue: getBaseUrl() }];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
