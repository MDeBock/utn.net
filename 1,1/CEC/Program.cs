// Mineria Espacial CEC por Matias Sanchez De Bock

using Enums;

Random random = new Random();

int coordenadaX, coordenadaY, cantidadTiposAsteroride,cantidadMetalesAsteroide;

// cantidad de tipos de asteroides
cantidadTiposAsteroride = Enum.GetValues(typeof(TamañoAsteroide)).Length;

// la cantidad de tipos de metales 
cantidadMetalesAsteroide = Enum.GetValues(typeof(Metales)).Length;

//obtener un array de los metales a minar
string [] listaMetales = new string[cantidadMetalesAsteroide];
listaMetales = ListadoMetales();

//rangos de las coordenadas de un sistema
coordenadaX = new Random().Next(1,100+1);
coordenadaY = new Random().Next(1,100+1);

int [] metalesTotales = new int [cantidadMetalesAsteroide];
int [] metalesPorSistema = new int [cantidadMetalesAsteroide];
int [] metalesPorAstereoide = new int [cantidadMetalesAsteroide];

bool control = true;

Console.WriteLine("iniciando sistema CEC");

while(control){
    string sistema = NombreSistema(coordenadaX,coordenadaY);
    Console.WriteLine($"viajando al sistema {sistema}");
    int cantidadAsteroides = AsteoridesCoordenada();
    Console.WriteLine($"el sistema posee {cantidadAsteroides} asteroide/s");
    Console.WriteLine("minando");
    for (int i = 0; i < cantidadAsteroides; i++){
        int asteroide = TipoAsteroide();
        if(i == 0){
            metalesPorSistema = CantidadMetales(asteroide);
        }else{
            metalesPorAstereoide = CantidadMetales(asteroide);
            for(int j = 0; j < metalesPorAstereoide.Length; j++){
                metalesPorSistema[j] += metalesPorAstereoide[j];
            }
        }        
    }
    Console.WriteLine("se mino un todal de:");
    for (int i = 0; i < metalesTotales.Length; i++){
            Console.WriteLine($"{listaMetales[i]} = {metalesPorSistema[i]}");
    }
    for (int i = 0; i < metalesTotales.Length; i++){
        metalesTotales[i] += metalesPorSistema[i]; 
    }
    Console.WriteLine($"el sistema {sistema} fue minado por completo, desea continuar? (y/n)");
    string respuesta = Console.ReadLine().ToLower();
    if(respuesta != "y"){
        control = false;
        Console.WriteLine("se mino un total de;");
        for (int i = 0; i < metalesTotales.Length; i++){
            Console.WriteLine($"{listaMetales[i]} = {metalesTotales[i]}");
        }
        Console.WriteLine("programa finalizado");
    }
}


//funciones---------------------------------------------------------------------------------------

string NombreSistema (int x, int y){

    int valorX = new Random().Next(1,x);
    int valorY = new Random().Next(1,y);
    string coordenada = "X" + valorX.ToString() + "Y" + valorY.ToString();

    return coordenada;
}

int AsteoridesCoordenada(){

    int cantidadAsteroides = new Random().Next(1,10+1);  

    return cantidadAsteroides;
}

int TipoAsteroide (){

    int [] tamañosAsteorides = new int[cantidadTiposAsteroride];
    int lugar = 0;    
    foreach (TamañoAsteroide dato in Enum.GetValues(typeof(TamañoAsteroide))){
        int cantidad = (int)dato;
        //Console.WriteLine(cantidad);
        tamañosAsteorides[lugar] = cantidad;
        lugar++;       
    }
    int item = random.Next(0, cantidadTiposAsteroride);

    return tamañosAsteorides[item];
}

int[] CantidadMetales (int dato){

    int [] metales = new int [cantidadMetalesAsteroide];
    int metalesMax = dato;

    for (int i = 0; i < cantidadMetalesAsteroide; i++){
        int metal = random.Next(0, metalesMax);
        metalesMax -= metal;
        metales[i] = metal;
        if (i == cantidadMetalesAsteroide - 1){
            metales[i] += metalesMax;            
        }
    }

    return metales;

}

string [] ListadoMetales (){

    string [] datos = new string[cantidadMetalesAsteroide];
    int lugar = 0;    
    foreach (var dato in Enum.GetNames(typeof(Metales))){
        string nombre = dato.ToString();
        //Console.WriteLine(nombre);
        datos[lugar] = nombre;
        lugar++;       
    }   

    return datos;
}

