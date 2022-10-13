export interface JsonCancion{
    codigo:Int16Array
    mensaje:Cancion
}

export interface Cancion{
    id:Int16Array
    titulo:string
    descripcion:string
    duracion:Int16Array
    autor:string
    linkAudio:string
    linkImagen:string
    categoriasMusicales:string[]
}