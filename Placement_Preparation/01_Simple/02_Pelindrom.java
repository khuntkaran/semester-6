import java.util.Scanner;

public class pelindrom{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter Number:");
        int n=sc.nextInt();
        int i=n,a=0;
        while(i>0){
            a=(a*10)+(i%10);
            i=i/10;
        }
        if(a==n){
            System.out.println("Number is Pelindrom");
        }
        else{
            System.out.println("Numer is not Pelindroms");
        } 
    }
}