﻿namespace LINQSamples
{
    public class SamplesViewModel : ViewModelBase
    {
        #region WhereQuery
        /// <summary>
        /// Filter products using where. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Query Syntax Here
            list = (from product in products
                    where product.Name.StartsWith("S")
                    select product)
                    .ToList();

            return list;
        }
        #endregion

        #region WhereMethod
        /// <summary>
        /// Filter products using where. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Method Syntax Here
            list = products
                .Where(product => product.Name.StartsWith("S"))
                .ToList();

            return list;
        }
        #endregion

        #region WhereTwoFieldsQuery
        /// <summary>
        /// Filter products using where with two fields. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereTwoFieldsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from product in products
                    where product.Name.StartsWith("L") &&
                    product.StandardCost > 200
                    select product)
                    .ToList();

            return list;
        }
        #endregion

        #region WhereTwoFieldsMethod
        /// <summary>
        /// Filter products using where with two fields. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereTwoFieldsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Method Syntax Here
            list = products
                .Where(product => product.Name.StartsWith("L") && product.StandardCost > 200)                
                .ToList();


            return list;
        }
        #endregion

        #region WhereExtensionQuery
        /// <summary>
        /// Filter products using a custom extension method
        /// </summary>
        public List<Product> WhereExtensionQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Query Syntax Here
            list = (from product in products
                    select product)
                    .ByColor("Red")
                    .ToList();

            return list;
        }
        #endregion

        #region WhereExtensionMethod
        /// <summary>
        /// Filter products using a custom extension method
        /// </summary>
        public List<Product> WhereExtensionMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Method Syntax Here
            list = products
                .ByColor("Red")
                .ToList();

            return list;
        }
        #endregion
    }
}
