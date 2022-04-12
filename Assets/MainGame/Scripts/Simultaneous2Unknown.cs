using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  class Simultaneous2Unknown
    {
        private double[] x_coefficients;
        private double[] y_coefficients;
        private double[] equals;
        private double[,] eliminator;
        private double x_variable;
        private double y_variable;

        public Simultaneous2Unknown(double[] x_coeff, double[] y_coeff, double[] eq)
        {
            x_coefficients = new double[] { x_coeff[0], x_coeff[1] };
            y_coefficients = new double[] { y_coeff[0], y_coeff[1] };
            equals = new double[] { eq[0], eq[1] };
            eliminator = new double[2, 2];
        }

        public double[] SolveSimultaneous()
        {
            // STEP 2:
            eliminator[0, 0] = y_coefficients[1] * x_coefficients[0];
            eliminator[0, 1] = y_coefficients[1] * equals[0];
            // STEP 3:
            eliminator[1, 0] = y_coefficients[0] * x_coefficients[1];
            eliminator[1, 1] = y_coefficients[0] * equals[1];

            try
            {
                // STEPS 4, 5:
                x_variable = (eliminator[0, 1] - eliminator[1, 1]) / (eliminator[0, 0] - eliminator[1, 0]);
                // STEP 6:
                y_variable = (equals[0] - x_coefficients[0] * x_variable) / y_coefficients[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            return new double[] { x_variable, y_variable };
        }
    }

