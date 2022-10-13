import { Cancion } from './InterfacesCanciones'

export interface JsonPlayListPost{
    codigo:Int16Array
    mensaje:string
}

export interface JsonPlayList{
    codigo:Int16Array
    mensaje:PlayList
}

export interface PlayList{
    id:Int16Array
    nombre:string
    descripcion:string
    canciones:Cancion[]
    listaCategorias:string[]
}
