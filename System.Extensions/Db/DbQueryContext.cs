﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Db
{
    public class DbQueryContext<TResult>
    {
        internal static object Execute(Expression expression, bool isEnumerable, IQueryable<TResult> results) // string root
        {
            var queryableElements = results; // GetAllFilesAndFolders(root);

            // Copy the expression tree that was passed in, changing only the first
            // argument of the innermost MethodCallExpression.
            var treeCopier = new ExpressionTreeModifier<TResult>(queryableElements);

            var newExpressionTree = treeCopier.Visit(expression);

            // This step creates an IQueryable that executes by replacing Queryable methods with Enumerable methods.
            if (isEnumerable)
            {
                return queryableElements.Provider.CreateQuery(newExpressionTree);
            }
            else
            {
                return queryableElements.Provider.Execute(newExpressionTree);
            }
        }

        //private static IQueryable<TResult> GetAllFilesAndFolders(string root)
        //{
        //    var list = new List<FileSystemElement>();
        //    foreach (var directory in Directory.GetDirectories(root))
        //    {
        //        list.Add(new FolderElement(directory));
        //    }
        //    foreach (var file in Directory.GetFiles(root))
        //    {
        //        list.Add(new FileElement(file));
        //    }
        //    return list.AsQueryable();
        //}
    }
}
