string fraseIngresada = "No hay nadie que ame el dolor de por sí, que lo busque y quiera tenerlo, simplemente por el hecho de ser dolor";

//Console.WriteLine("ingrese la palabra o frace que quiera traducir");

//string fraseIngresada = Console.ReadLine();

string fraseTraducida = "";

string fraseDepurada = DepurarFrase(fraseIngresada);

string[] listaPalabras = fraseDepurada.ToLower().Split(' ');

foreach (string palabra in listaPalabras){
    string traduccionPalabra = SegundaRegla(palabra) + PrimeraRelga(palabra) + palabra + TerceraRegla(palabra) + " ";
    fraseTraducida += traduccionPalabra;
}

Console.WriteLine(fraseTraducida);

// funciones

string DepurarFrase (string frase){

    // quitar "," "." y "´"

    string resultado = "";
    string resultadoParcial = "";

    foreach(char c in frase){
        if (c != ',' && c != '.'){        
            resultadoParcial += c.ToString();
        }
    }

    foreach(char c in resultadoParcial){
        if (c == 'á'){        
            resultado = resultado + c.ToString().Replace("á", "a");
        }else if (c == 'é'){
            resultado = resultado + c.ToString().Replace("é", "e");
        }else if (c == 'í'){
            resultado = resultado + c.ToString().Replace("í", "i");
        }else if (c == 'ó'){
            resultado = resultado + c.ToString().Replace("ó", "o");
        }else if (c == 'ú'){
            resultado = resultado + c.ToString().Replace("ú", "u");
        }else{
            resultado = resultado + c.ToString();
        }
    }

    return resultado;
}

bool EsVocal(char letra){
    return (letra == 'a' || letra == 'e' || letra == 'i' || letra == 'o' || letra == 'u');
}

string PrimeraRelga (string palabra){
    
    // Si una palabra empieza con vocal, entonces la primera vocal se duplica, a menos que la segunda letra sea también sea una vocal; en ese caso ignoramos la regla.

    string resultado = "";

    if ((palabra.Length > 1) && (EsVocal(palabra.ElementAt(0)) && (!EsVocal(palabra.ElementAt(1))))){
            resultado = palabra[0].ToString();            
        }
    
    return resultado;
}

string SegundaRegla (string palabra){

    //Si una palabra tiene más de 6 letras de largo, debemos agregar “an” al principio, antes de primer sufijo, y luego de aplicar la primera regla.

    string resultado = "";

    if (palabra.Length > 6){
        resultado = "an";
    }

    return resultado;
}

string TerceraRegla (string palabra){

    //Si una palabra termina en n, s o vocal, entonces debemos agregar “sten” al final de la palabra, a menos que la vocal sea ‘o’, en ese caso debemos agregar “so” en lugar.

    string resultado = "";       

    int largoPalabra = palabra.Length - 1; 
       
    if (palabra.Length > 1){
        
        if ((palabra[largoPalabra] == 'n' || palabra[largoPalabra] == 's' || EsVocal(palabra.ElementAt(largoPalabra))) && palabra[largoPalabra] != 'o'){
            resultado = "sten";
        }else if(palabra[largoPalabra] == 'o'){
            resultado = "so";
        }
    }

    return resultado;
}