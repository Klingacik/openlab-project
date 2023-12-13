import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GuildDetails } from 'src/app/guild/guild.component'

@Injectable({
  providedIn: 'root'
})
export class GuildService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getGuildDetails(guildId: number): Observable<any> {
    return this.http.get<any>(this.baseUrl + 'guild/' + guildId);
  }


  joinGuild(guildId: number) {
    this.http.post(this.baseUrl + 'guild/join', { guildId }).subscribe(result => {
      console.log('Joined guild successfully', guildId);
    }, error => {
      console.error('Error joining guild', error);
    });
  }

  leaveGuild(guildId: number) {
    this.http.post(this.baseUrl + 'guild/leave', { guildId }).subscribe(result => {
      console.log('Left guild successfully', guildId);
    },
      error => {
        console.error('Error leaving guild', error);
      }
    );
  }

}
