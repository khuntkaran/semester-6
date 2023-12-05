import java.util.Scanner;

public class Natural_Number_Without_Semicolon {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter N : ");
        int N = sc.nextInt();
        for(int i=0;i<N;i++,System.out.print(i+",")){}
    }
}