import java.util.*;
import java.io.*;

public class VacunacionCovid {

    public static void main(String[] args) throws Exception {
        // Conjunto total de ciudadanos
        Set<String> ciudadanos = new HashSet<>();
        for (int i = 1; i <= 500; i++) {
            ciudadanos.add("Ciudadano " + i);
        }

        // Vacunados con Pfizer
        Set<String> pfizer = new HashSet<>();
        for (int i = 1; i <= 75; i++) {
            pfizer.add("Ciudadano " + i);
        }

        // Vacunados con AstraZeneca
        Set<String> astrazeneca = new HashSet<>();
        for (int i = 50; i < 125; i++) { // algunos se cruzan con Pfizer
            astrazeneca.add("Ciudadano " + i);
        }

        // 1. No vacunados
        Set<String> noVacunados = new HashSet<>(ciudadanos);
        noVacunados.removeAll(pfizer);
        noVacunados.removeAll(astrazeneca);

        // 2. Ambas dosis (intersección)
        Set<String> ambasDosis = new HashSet<>(pfizer);
        ambasDosis.retainAll(astrazeneca);

        // 3. Solo Pfizer
        Set<String> soloPfizer = new HashSet<>(pfizer);
        soloPfizer.removeAll(astrazeneca);

        // 4. Solo AstraZeneca
        Set<String> soloAstraZeneca = new HashSet<>(astrazeneca);
        soloAstraZeneca.removeAll(pfizer);

        // Mostrar resultados en consola
        System.out.println("==== RESULTADOS VACUNACIÓN COVID ====");
        System.out.println("Total ciudadanos: " + ciudadanos.size());
        System.out.println("No vacunados: " + noVacunados.size());
        System.out.println("Ambas dosis: " + ambasDosis.size());
        System.out.println("Solo Pfizer: " + soloPfizer.size());
        System.out.println("Solo AstraZeneca: " + soloAstraZeneca.size());

        // Opcional: generar un reporte en PDF (simple .txt en este ejemplo)
        generarReporte(noVacunados, ambasDosis, soloPfizer, soloAstraZeneca);
    }

    // Método opcional para crear reporte
    public static void generarReporte(Set<String> noVacunados, Set<String> ambas, 
                                      Set<String> pfizer, Set<String> astra) throws Exception {
        FileWriter fw = new FileWriter("Reporte_Vacunacion.txt");
        fw.write("==== REPORTE VACUNACIÓN COVID ====\n\n");
        fw.write("No vacunados: " + noVacunados.size() + " -> " + noVacunados + "\n\n");
        fw.write("Ambas dosis: " + ambas.size() + " -> " + ambas + "\n\n");
        fw.write("Solo Pfizer: " + pfizer.size() + " -> " + pfizer + "\n\n");
        fw.write("Solo AstraZeneca: " + astra.size() + " -> " + astra + "\n\n");
        fw.close();
        System.out.println("Reporte generado: Reporte_Vacunacion.txt");
    }
}
