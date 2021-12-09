using FunTree.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTree.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Node root = null; 
            BinaryTree binaryTree = new BinaryTree();
            
            root = binaryTree.Add(5, root);
            root = binaryTree.Add(15, root);
            root = binaryTree.Add(17, root);
            root = binaryTree.Add(7, root);
            root = binaryTree.Add(25, root);
            root = binaryTree.Add(2, root);
            root = binaryTree.Add(18, root);

            var bb = root;

            StringBuilder sb = new StringBuilder();
            //now display. 
            var result = DisplayMyTree(root, sb);

            ViewBag.tree = result; 
            return View(root);
        }

        //https://codepen.io/Gerim/pen/pWrqXG 
        private string DisplayMyTree(Node root, StringBuilder sb)
        {        

            if (root != null)
            {
                PrintNode(root, sb);

                if (root.left != null) 
                { 
                    DisplayMyTree(root.left, sb);
                }
                if (root.right != null)
                {
                    DisplayMyTree(root.right, sb);
                }

            }

            return sb.ToString();

        }

        private void PrintNode(Node root, StringBuilder sb)
        {
            sb.Append(@"<ul><li> <a href=""#"">" + root.data + "</a>");

            if (root.left != null)
            {
                printChildLeft(root, sb); //current node's child's print
                
            }           
            //next it prints right nodes.
            if (root.right != null)
            {

                printChildRight(root, sb);  //current node's child's print              

            }

            sb.Append(@" </ul></li>");
        }

        private void printChildLeft(Node root, StringBuilder sb)
        {
                     
            if (root.left != null)
            {
                sb.Append(@"<li> <a href=""#"">" + root.left.data + "</a></li>");
            }
          
            
        }

        private void printChildRight(Node root, StringBuilder sb)
        {
          
            if (root.right != null)
            {
                sb.Append(@"<li> <a href=""#"">" + root.right.data + "</a></li>");
            }

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
