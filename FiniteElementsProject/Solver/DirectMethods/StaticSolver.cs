﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiniteElementsProject
{
    class StaticSolver : ISolver
    {
        private double[] staticSolutionVector;
        private LinearSolution solutionMethod;
        private NonLinearSolution nonLinearSolutionMethod;

        public void SetSolutionMethodToGauss()
        {
            solutionMethod = new GaussSolver();
        }

        public void SetSolutionMethodToCholesky()
        {
            solutionMethod = new CholeskyFactorization();
        }

        public void SetSolutionMethodToPCG()
        {
            solutionMethod = new PCGSolver();
        }

        public void SetNonLinearMethodToLoadControlledNewtonRaphson(Discretization2DFrame discretization)
        {
            nonLinearSolutionMethod = new LoadControlledNewtonRaphson(discretization);
        }

        public void ReadBoundaryConditions(int[] boundaryCond)
        {
            nonLinearSolutionMethod.DefineBoundaryConditions(boundaryCond);
        }

        public void Solve(double[,] coefMatrix, double[] rhsVector)
        {
            staticSolutionVector = solutionMethod.Solve(coefMatrix, rhsVector);
        }

        public void NLSolve(double[] rhsVector)
        {
            staticSolutionVector = nonLinearSolutionMethod.NLSolve(rhsVector);
        }

        public void PrintSolution()
        {
            VectorOperations.PrintVector(staticSolutionVector);
        }

    }
}
