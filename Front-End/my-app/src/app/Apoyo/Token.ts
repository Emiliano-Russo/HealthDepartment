import { HttpHeaders } from '@angular/common/http';

export function GetToken() {
  let httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      token: sessionStorage.getItem('token') + '',
    }),
  };
  return httpOptions;
}
