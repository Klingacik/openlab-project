import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  public xpAndGuild!: UserInfo;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<UserInfo>(baseUrl + 'user').subscribe(result => {
      this.xpAndGuild = result;
    }, error => console.error(error));
  }
}

export interface UserInfo {
  xp: number;
  guild: string;
}
