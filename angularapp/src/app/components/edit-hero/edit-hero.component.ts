import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SuperHero } from 'src/app/models/super-hero';
import { SuperHeroService } from 'src/app/services/super-hero.service';

@Component({
  selector: 'app-edit-hero',
  templateUrl: './edit-hero.component.html',
  styleUrls: ['./edit-hero.component.css']
})
export class EditHeroComponent {
  @Input() hero?: SuperHero;
  @Output() herosUpdated = new EventEmitter<SuperHero[]>();

  constructor(private superHeroService: SuperHeroService) {}

  updateHero(hero: SuperHero) {
    this.superHeroService
      .updateHero(hero)
      .subscribe({
        next: result => { this.herosUpdated.emit(result) }
    })
  }

  deleteHero(hero: SuperHero){
    this.superHeroService
      .deleteHero(hero)
      .subscribe({
        next: result => { this.herosUpdated.emit(result) }
    })
  }

  createHero(hero: SuperHero){
    this.superHeroService
      .createHero(hero)
      .subscribe({
        next: result => { this.herosUpdated.emit(result) }
    })
  }
}
