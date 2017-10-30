import { inject } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
//import { HttpClient, json } from 'aurelia-fetch-client';

@inject(HttpClient)
export class HomesApi {
  constructor(httpClient) {
    this.client = httpClient;
  }
  loadHomes(matchString) {
    let apiString;
    if (matchString) {
      apiString = `homes/homes?match=${matchString}`;
    } else {
      apiString = 'homes/homes';
    }
    return this.client.fetch(apiString);
  }

  loadCategories(matchString) {
    let apiString;
    if (matchString) {
      apiString = `homes/categories?match=${matchString}`;
    } else {
      apiString = 'homes/categories';
    }
    return this.client.fetch(apiString);
  }

  loadRegions(matchString) {
    let apiString;
    if (matchString) {
      apiString = `homes/regions?match=${matchString}`;
    } else {
      apiString = 'homes/regions';
    }
    return this.client.fetch(apiString);
  }

  createNewCategory(category) {
    //this.client.fetch('homes/category', { method: 'post', body: json(category) });
  }

  createNewHome(home) {
    //this.client.fetch('homes/home', { method: 'post', body: json(home) });
  }

  saveImage(image) {
    console.log('sending');
    console.log(json(image));
    return this.client.fetch('/homes/image');//?name=${image.name}`);//, { method: 'post', body: json(image) });
  }

  guid() {
    return `${this.s4()}${this.s4()}-${this.s4()}-${this.s4()}-${this.s4()}-${this.s4()}${this.s4()}${this.s4()}`;
  }
  s4() {
    return Math.floor((1 + Math.random()) * 0x10000)
      .toString(16)
      .substring(1);
  }
}
