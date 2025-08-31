import java.util.*;

public class Traductor {

    // Diccionario inglés → español
    private static Map<String, String> diccionario = new HashMap<>();

    public static void main(String[] args) {
        inicializarDiccionario();
        Scanner sc = new Scanner(System.in);
        int opcion;

        do {
            System.out.println("\n==== MENÚ ====");
            System.out.println("1. Traducir una frase");
            System.out.println("2. Agregar palabras al diccionario");
            System.out.println("0. Salir");
            System.out.print("Seleccione una opción: ");
            opcion = sc.nextInt();
            sc.nextLine(); // limpiar buffer

            switch (opcion) {
                case 1:
                    traducirFrase(sc);
                    break;
                case 2:
                    agregarPalabra(sc);
                    break;
                case 0:
                    System.out.println("Saliendo del traductor...");
                    break;
                default:
                    System.out.println("Opción no válida, intente de nuevo.");
            }
        } while (opcion != 0);

        sc.close();
    }

    // Inicializamos el diccionario con algunas palabras
    private static void inicializarDiccionario() {
        diccionario.put("time", "tiempo");
        diccionario.put("person", "persona");
        diccionario.put("year", "año");
        diccionario.put("way", "camino");
        diccionario.put("day", "día");
        diccionario.put("thing", "cosa");
        diccionario.put("man", "hombre");
        diccionario.put("world", "mundo");
        diccionario.put("life", "vida");
        diccionario.put("hand", "mano");
        diccionario.put("part", "parte");
        diccionario.put("child", "niño");
        diccionario.put("eye", "ojo");
        diccionario.put("woman", "mujer");
        diccionario.put("place", "lugar");
        diccionario.put("work", "trabajo");
        diccionario.put("week", "semana");
        diccionario.put("case", "caso");
        diccionario.put("point", "punto");
        diccionario.put("government", "gobierno");
        diccionario.put("company", "empresa");
    }

    // Traducción de frases palabra por palabra
    private static void traducirFrase(Scanner sc) {
        System.out.print("Ingrese una frase: ");
        String frase = sc.nextLine();

        String[] palabras = frase.split(" ");
        StringBuilder traduccion = new StringBuilder();

        for (String palabra : palabras) {
            String palabraLimpia = palabra.toLowerCase().replaceAll("[^a-zA-Z]", "");
            String traduccionPalabra = diccionario.get(palabraLimpia);

            if (traduccionPalabra != null) {
                // Conservamos la puntuación
                traduccion.append(palabra.replaceAll("(?i)" + palabraLimpia, traduccionPalabra)).append(" ");
            } else {
                traduccion.append(palabra).append(" ");
            }
        }

        System.out.println("Traducción: " + traduccion.toString().trim());
    }

    // Permitir al usuario agregar nuevas palabras al diccionario
    private static void agregarPalabra(Scanner sc) {
        System.out.print("Ingrese la palabra en inglés: ");
        String ingles = sc.nextLine().toLowerCase();

        System.out.print("Ingrese su traducción al español: ");
        String espanol = sc.nextLine().toLowerCase();

        diccionario.put(ingles, espanol);
        System.out.println("Palabra agregada con éxito: " + ingles + " → " + espanol);
    }
}
