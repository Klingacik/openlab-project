import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { getBaseUrl } from '../../main';
import { HttpClient } from '@angular/common/http';
import { GuildDetails } from '../guild/guild.component';

@Component({
  selector: 'app-guild-detail',
  templateUrl: './guild-detail.component.html',
  styleUrls: ['./guild-detail.component.css']
})

export class GuildDetailComponent implements OnInit {
  public guildData: GuildDetails;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    // Retrieve the guild ID from the route parameters
    const guildId = this.route.snapshot.paramMap.get('id');

    // Fetch guild details based on the guild ID
    this.http.get<GuildDetails>(`${this.baseUrl}guild/${guildId}`).subscribe(result => {
      this.guildData = result;
    }, error => console.error(error));
  }
}
