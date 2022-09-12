// Language: java
// Path: calculator.java
//scientific calculator with parentheses and negative on a single line of input
// 1+2*(3+4)-5
// 1+2*3+4-5

import java.util.*;
import java.io.*;
import java.lang.*;

public class calculator {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        String input = in.next();
        Stack<Character> ops = new Stack<Character>();
        Stack<Double> vals = new Stack<Double>();
        int i = 0;
        while(i < input.length()) {
            char c = input.charAt(i);
            if(c == '(') {
                ops.push(c);
            } else if(c == ')') {
                while(ops.peek() != '(') {
                    double v = vals.pop();
                    char op = ops.pop();
                    if(op == '+') {
                        v = vals.pop() + v;
                    } else if(op == '-') {
                        v = vals.pop() - v;
                    } else if(op == '*') {
                        v = vals.pop() * v;
                    } else if(op == '/') {
                        v = vals.pop() / v;
                    }
                    vals.push(v);
                }
                ops.pop();
            } else if(c == '+') {
                ops.push(c);
            } else if(c == '-') {
                ops.push(c);
            } else if(c == '*') {
                ops.push(c);
            } else if(c == '/') {
                ops.push(c);
            } else {
                double v = 0;
                while(i < input.length() && input.charAt(i) >= '0' && input.charAt(i) <= '9') {
                    v = v * 10 + (input.charAt(i) - '0');
                    i++;
                }
                vals.push(v);
                i--;
            }
            i++;
        }
        while(!ops.isEmpty()) {
            double v = vals.pop();
            char op = ops.pop();
            if(op == '+') {
                v = vals.pop() + v;
            } else if(op == '-') {
                v = vals.pop() - v;
            } else if(op == '*') {
                v = vals.pop() * v;
            } else if(op == '/') {
                v = vals.pop() / v;
            }
            vals.push(v);
        }
        System.out.println(vals.pop());
    }
}

// Language: