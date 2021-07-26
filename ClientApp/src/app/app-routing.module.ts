import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { RankComponent } from './rank/rank.component';
import { SearchComponent } from './search/search.component';

const routes: Routes = [
  { path: '', component: RankComponent },
  { path: 'search', component: SearchComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
