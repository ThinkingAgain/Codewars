public class Kyu6 {
    public static void main(String args[]){
        System.out.println(findNb(91716553919377L));
    }

    /**
     * Build a pile of Cubes
     * return the integer n such as n^3 + (n-1)^3 + ... + 1^3 = m if such a n exists or -1 if there is no such n.
     * @param m
     * @return n
     */
    public static long findNb(long m) {
        if (m < 1) return -1;
        long sum = 0;
        long n = 0;
        while (sum < m){
            n++;
            sum += n*n*n;
        }
        if (sum == m) return n;
        return -1;
    }





}
