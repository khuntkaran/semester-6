import java.util.Scanner;

public class Patten {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter Number of Line : ");
        int n = sc.nextInt();
        int k=0;
        for(int i=0;i<n & k<n;i++,k++){
            for(int j=(2*i*n)+1;j<(2*i*n)+1+n;j++){
                System.out.print(j+" ");
            }
            System.out.println();
            k++;
            if(k==n){
                break;
            }
            for(int j=(2*i*n)+(2*n);j>(2*i*n)+n;j--){
                System.out.print(j+" ");
            }
            System.out.println();
        }
    }
}
