import java.util.Scanner;

public class PrimeNo_01 {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n;
        System.out.println("Enter Number to check prime or not:");
        n=sc.nextInt();
        boolean flag=true;
        for(int i=2; i<=n/2; i++){
            if(n%i==0){
                flag=false;
                break;
            }
        }
        if(flag==true){
            System.out.println("Number is prime");
        }
        else{
            {
            System.out.println("Number is not prime");
        }
        }

        System.out.println();
    }
}
