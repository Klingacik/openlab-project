import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { getBaseUrl } from '../../main';
import { HttpClient } from '@angular/common/http';
import { GuildDetails } from '../guild/guild.component';

//import { Guild, guilds } from '../guild';

@Component({
  selector: 'app-guild-detail',
  templateUrl: './guild-detail.component.html',
  styleUrls: ['./guild-detail.component.css']
})

export class GuildDetailComponent {

    public guildData: GuildDetails[] = [];
    constructor(http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
    http.get<GuildDetails[]>(baseUrl + 'guild').subscribe(result => {
      this.guildData = result;

    }, error => console.error(error));
  }

}
