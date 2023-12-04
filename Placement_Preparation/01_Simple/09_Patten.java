import java.util.Scanner;

public class Patten {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter Number of Line : ");
        int n = sc.nextInt();

        for(int i=0;i<n;i++){
            for(int j=(i*n)+1;j<(i*n)+1+n;j++){
                System.out.print(j+" ");
            }
            System.out.println();
            for(int j=(i*n)+1+(2*n);j>(i*n)+1+n;j--){
                System.out.print(j+" ");
            }
            System.out.println();
        }
    }
}
