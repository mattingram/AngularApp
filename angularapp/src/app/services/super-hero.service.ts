import { Injectable } from '@angular/core';
import { SuperHero } from '../models/super-hero';
@Injectable({
  providedIn: 'root'
})
export class SuperHeroService {

  constructor() { }

  public getSuperHeros() : SuperHero[] {
    let hero = new SuperHero();
    hero.id = 1;
    hero.name = "Spiderman";
    hero.firstName = "Peter";
    hero.lastName = 'Parker';
    hero.place = 'NYC';

    return [hero];
  }
}
