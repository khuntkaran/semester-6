import java.util.Scanner;
import java.lang.Math;

public class decimaltobinary {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        System.out.println("Enter number");
        int n= sc.nextInt();
        int x=n,i=0,b=0;
        int binary=0;
        while(x>1){
            x=(int)x/2;
            i++;
        }
        x=n;
        for(int j=i;j>=0; j-- ){
            if(x-Math.pow(2, j)>=0){
                x=x-(int)Math.pow(2,j);
                binary=(binary*10)+1;
            }
            else{
                binary=(binary*10)+0;
            }
        }
        System.out.println("Binary:"+binary);
    }
}

    

