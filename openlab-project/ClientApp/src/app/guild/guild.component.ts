import { Injectable } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-guild',
  templateUrl: './guild.component.html',
  styleUrls: ['./guild.component.css']
})

export class GuildComponent {
  Name: string = "no data";
  Description: string = "no data";
  Capacity: number = 0;
  MembersCount: number = 0;
  public guildData: GuildDetails[] = [];
  
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<GuildDetails[]>(baseUrl + 'guild').subscribe(result => {
      this.guildData = result;

    }, error => console.error(error));
  }
}

export interface GuildDetails {
  name: string;
  id: number;
  description: string;
  capacity: number;
  membersCount: number;
}
