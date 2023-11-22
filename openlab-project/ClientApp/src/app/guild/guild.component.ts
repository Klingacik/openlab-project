import { Injectable } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

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
<<<<<<< HEAD
  
  constructor(http: HttpClient, private router: Router, @Inject('BASE_URL') baseUrl: string) {
=======

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) {
>>>>>>> JOIN button
    http.get<GuildDetails[]>(baseUrl + 'guild').subscribe(result => {
      this.guildData = result;
    }, error => console.error(error));
  }

  joinGuild(guildId: number) {
    this.http.post(this.baseUrl + 'guild/join', { guildId }).subscribe(result => {
      console.log('Joined guild successfully', guildId);
    }, error => {
      console.error('Error joining guild', error);
    });
  }
}

export interface GuildDetails {
  name: string;
  id: number;
  description: string;
  capacity: number;
  membersCount: number;
}
