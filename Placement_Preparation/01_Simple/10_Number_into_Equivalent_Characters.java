import java.util.Scanner;
public class Number_into_Equivalent_Characters {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter String : ");
        String str= sc.nextLine();
        int k=1;
        for(int i=0;i<str.length();i++){
            k=1;
            if(Character.isDigit(str.charAt(i))){
                k=Character.getNumericValue(str.charAt(i));
                i++;
            }
            while (k>0) {
                System.out.print(str.charAt(i));
                k--;
            }
        }
    }
}