import { Cancion } from './InterfacesCanciones'
import { PlayList } from './InterfacesPlayList'

export interface JsonGaleriaMusical{
    codigo:Int16Array
    mensaje:GaleriaMusical
}
export interface GaleriaMusical{
    categoriaMusical:string
    playLists:PlayList[]  
    canciones:Cancion[]
}


