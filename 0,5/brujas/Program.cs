// Veterinaria Las Tres Brujas por Matias Sanchez De Bock

string empleada, alimento;
double dineroEnCaja = 1000, precioComidaGatos = 50, precioComidaPerros = 50, monto;
int stockComidaGatos = 100, stockComidaPerros = 100, cantidad;

Console.WriteLine("ingrese el nombre de la empleada");

empleada = Console.ReadLine();

Console.WriteLine($"hola {empleada}");

switch(empleada.ToLower()){

    case "andurias":    
    Console.WriteLine("ingrese la cantidad que desea modificar");
    monto = double.Parse(Console.ReadLine());
    if((dineroEnCaja + monto)>= 0){
        dineroEnCaja += monto;
    }else{
        Console.WriteLine("el dinero en caja no es suficiente");
    }
    break;

    case "asterios":
    Console.WriteLine("que alimento desea modificar?");
    alimento = Console.ReadLine();    
    Console.WriteLine("ingrese la cantidad que desea modificar?");
    cantidad = int.Parse(Console.ReadLine());
    if (alimento.ToLower() == "gatos" && cantidad <= stockComidaGatos){
        stockComidaGatos -= cantidad;
    }else if (alimento.ToLower() == "perros" && cantidad <= stockComidaPerros){
        stockComidaPerros -= cantidad;
    }else{
        Console.WriteLine("no vendemos ese alimento o el stock no es suficiente");
    }
    break;

    case "penurias":
    Console.WriteLine("que alimento desea modificar?");
    alimento = Console.ReadLine();    
    Console.WriteLine("ingrese la cantidad que desea modificar?");
    cantidad = int.Parse(Console.ReadLine());
    if (alimento.ToLower() == "gatos" && (cantidad * precioComidaGatos)<= dineroEnCaja){
        stockComidaGatos += cantidad;
        dineroEnCaja -= (cantidad * precioComidaGatos);
    }else if (alimento.ToLower() == "perros" && (cantidad * precioComidaPerros)<= dineroEnCaja){
        stockComidaPerros += cantidad;
        dineroEnCaja -= (cantidad * precioComidaPerros);
    }else{
        Console.WriteLine("no vendemos ese alimento o el dinero no es suficiente");
    }
    break; 
    default:
    Console.WriteLine("ud no es una empleada autorizada");
    break;   
}

Console.WriteLine($"en la caja hay ${dineroEnCaja}");
Console.WriteLine($"el stock de comida para gatos es de: {stockComidaGatos}");
Console.WriteLine($"el stock de comida para perros es de: {stockComidaPerros}");