import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';

//Componentes Solucion
import { BienvenidaComponent } from '../Bienvenida/bienvenida.component';
import { CategoriasMusicalesComponent } from '../Musica/Componentes/CategoriasMusicales/musica.categorias_musicales.component';
import { GaleriaMusicalComponent } from '../Musica/Componentes/GaleriaMusical/galeria.musical.component';
import { PlayListComponent } from '../Musica/Componentes/PlayList/playlist.component';
import { PsicologiaCategoriasComponent } from '../Psicologia/CategoriasPsicologia/psicologia.categorias.component';
import { AgendarCitaComponent } from '../Psicologia/AgendarCita/agendar.cita.component';
import { CitaResultadoComponent } from '../Psicologia/CitaResultado/cita.resultado.component';
import { AltaPsicologoComponent } from '../ComponentesAdmins/AltaPsicologo/alta.psicologo.component';
import { BajaPsicologoComponent } from '../ComponentesAdmins/BajaPsicologo/baja.psicologo.component';
import { ListaPsicologosModificablesComponent } from '../ComponentesAdmins/ListaPsicologosModificables/lista.psicologos.modificables.component';
import { MenuFuncionalidadesComponent } from '../ComponentesAdmins/MenuFuncionalidades/menu.funcionalidades.component';
import { ModificarPsicologoComponent } from '../ComponentesAdmins/ModificarPsicologo/modificar.psicologo.component';
import { SeccionAltaCancionOVideoComponent } from '../ComponentesAdmins/SeccionAltaCancionOVideo/seccion.alta.cancion.o.video.component';
import { DescuentoEmailsComponent } from '../ComponentesAdmins/DescuentoEmails/descuento.emails.component';
import { AltaVideoComponent } from '../ComponentesAdmins/AltaVideo/alta.video.component';
import { BajaContenidoComponent } from '../ComponentesAdmins/BajaContenido/baja.contenido.component';
import { AdminBienvenidaComponent } from '../ComponentesAdmins/AdminBienvenida/admin.bienvenida.component';
import { AgregarAdminComponent } from '../ComponentesAdmins/AgregarAdmin/agregar.admin.component';
import { AltaCancionComponent } from '../ComponentesAdmins/AltaCancion/alta.cancion.component';
import { AdminLoginComponent } from '../AdminLogin/admin.login.component';
import { ReflectionComponent } from '../ComponentesAdmins/Reflection/reflection.component';
import { NavMenuComponent } from '../Nav-menu/nav-menu.component';
import { RegistrarPlaylistComponent } from '../ComponentesAdmins/RegistrarPlaylist/registrar.playlist.component';

@NgModule({
  declarations: [
    AppComponent,
    BienvenidaComponent,
    CategoriasMusicalesComponent,
    GaleriaMusicalComponent,
    PlayListComponent,
    PsicologiaCategoriasComponent,
    AgendarCitaComponent,
    CitaResultadoComponent,
    AltaPsicologoComponent,
    BajaPsicologoComponent,
    ListaPsicologosModificablesComponent,
    MenuFuncionalidadesComponent,
    ModificarPsicologoComponent,
    SeccionAltaCancionOVideoComponent,
    AdminBienvenidaComponent,
    AgregarAdminComponent,
    AltaCancionComponent,
    AltaVideoComponent,
    BajaContenidoComponent,
    DescuentoEmailsComponent,
    AdminLoginComponent,
    ReflectionComponent,
    NavMenuComponent,
    RegistrarPlaylistComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot([
      { path: '', component: BienvenidaComponent, pathMatch: 'full' },
      { path: 'Musica', component: CategoriasMusicalesComponent },
      { path: 'GaleriaMusical', component: GaleriaMusicalComponent },
      { path: 'Playlist', component: PlayListComponent },
      { path: 'Psicologia', component: PsicologiaCategoriasComponent },
      { path: 'AgendarCita', component: AgendarCitaComponent },
      { path: 'CitaResultado', component: CitaResultadoComponent },
      { path: 'AltaPsicologo', component: AltaPsicologoComponent },
      { path: 'BajaPsicologo', component: BajaPsicologoComponent },
      {
        path: 'ListaPsicologosModificables',
        component: ListaPsicologosModificablesComponent,
      },
      { path: 'MenuFuncionalidades', component: MenuFuncionalidadesComponent },
      {
        path: 'ModificarPsicologo',
        component: ModificarPsicologoComponent,
      },
      {
        path: 'SeccionAltaCancionOVideo',
        component: SeccionAltaCancionOVideoComponent,
      },
      { path: 'AdminBienvenida', component: AdminBienvenidaComponent },
      { path: 'AgregarAdmin', component: AgregarAdminComponent },
      { path: 'AltaCancion', component: AltaCancionComponent },
      { path: 'AltaVideo', component: AltaVideoComponent },
      { path: 'BajaContenido', component: BajaContenidoComponent },
      { path: 'DescuentoEmails', component: DescuentoEmailsComponent },
      { path: 'AdminLogin', component: AdminLoginComponent },
      { path: 'Reflection', component: ReflectionComponent },
      { path: 'RegistrarPlaylist', component: RegistrarPlaylistComponent },
    ]),
  ],
  providers: [NavMenuComponent],
  bootstrap: [AppComponent],
})
export class AppModule {}
