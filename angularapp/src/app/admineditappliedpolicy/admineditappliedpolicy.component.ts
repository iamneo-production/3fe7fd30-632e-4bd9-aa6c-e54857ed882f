import { Component, OnInit } from '@angular/core';
import { ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-admineditappliedpolicy',
  templateUrl: './admineditappliedpolicy.component.html',
  styleUrls: ['./admineditappliedpolicy.component.scss']
})
export class AdmineditappliedpolicyComponent implements OnInit 
{
  constructor(private route : ActivatedRoute){}
  ngOnInit(): void{
    let PolicyId = this.route.snapshot.paramMap.get('id')
    console.warn(PolicyId);
  }

}



