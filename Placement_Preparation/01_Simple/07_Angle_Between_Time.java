import java.util.Scanner;
import java.lang.Math;
public class Angle_Between_Time{
    public static void main(String[] args){
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter Hour : ");
        int h= sc.nextInt();
        System.out.println("Enter Minute : ");
        int m = sc.nextInt();

        double deg = Math.abs((m*6)-(h*30+(0.5*m)));
        System.out.println(360-deg<deg?360-deg:deg);
    }
}