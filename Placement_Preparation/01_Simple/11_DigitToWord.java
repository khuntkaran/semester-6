import java.util.Scanner;
public class DigitToWord{
    public static void main(String[] args) {
        String [] oneToNine = {"Zero","One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine","Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
        String [] tens = {"Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninty"};

        Scanner sc = new Scanner(System.in);

        System.out.print("Enter the number : ");
        int n = sc.nextInt();

        if (n < 0 || n > 999){
            System.out.println("Please, Enter the number between 0 to 99.");
            return;
        }
        if(n>99){
            int temp=n/100;
            System.out.print(oneToNine[temp]+" Hundred ");
            n=n%100;
        }
        if (n < 21){
            System.out.println(oneToNine[n]);
        }
        else{
            System.out.println(tens[(n / 10)-2] + " " + oneToNine[n % 10]);
        }
    }
}