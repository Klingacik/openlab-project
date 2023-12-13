import { Injectable, signal } from '@angular/core';
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

  constructor(private http: HttpClient, private router: Router, @Inject('BASE_URL') private baseUrl: string) {
    http.get<GuildDetails>(baseUrl + 'guild').subscribe(guild => this.holakys.set(guild));
  }

  holakys = signal<GuildDetails>(undefined);

  joinGuild(guildId: number) {
    this.http.post<GuildDetails>(this.baseUrl + 'guild/join', { guildId }).subscribe(guildDetailJoin => this.holakys.set(guildDetailJoin));
    
  }

  leaveGuild(guildId: number) {
    this.http.post<GuildDetails>(this.baseUrl + 'guild/leave', { guildId }).subscribe(result => {
        console.log('Left guild successfully', guildId);
      },
      error => {
        console.error('Error leaving guild', error);
      }
    );
  }

}

export interface GuildDetails {
  name: string;
  id: number;
  description: string;
  capacity: number;
  membersCount: number;
}
