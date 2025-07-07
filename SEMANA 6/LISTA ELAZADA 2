import java.util.LinkedList;
import java.util.Random;
import java.util.Scanner;

public class ListaFiltrada {

    public static void main(String[] args) {
        LinkedList<Integer> lista = new LinkedList<>();
        Random random = new Random();

        // Llenar la lista con 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++) {
            lista.add(random.nextInt(999) + 1); // entre 1 y 999
        }

        System.out.println("Lista original:");
        System.out.println(lista);

        // Leer el rango desde el teclado
        Scanner scanner = new Scanner(System.in);
        System.out.print("Ingrese el valor mínimo del rango: ");
        int minimo = scanner.nextInt();

        System.out.print("Ingrese el valor máximo del rango: ");
        int maximo = scanner.nextInt();

        // Validar el rango
        if (minimo > maximo) {
            System.out.println("Rango inválido: el mínimo no puede ser mayor que el máximo.");
            return;
        }

        // Eliminar los elementos fuera del rango
        lista.removeIf(numero -> numero < minimo || numero > maximo);

        // Mostrar la lista filtrada
        System.out.println("Lista después de eliminar los valores fuera del rango:");
        System.out.println(lista);
    }
}
