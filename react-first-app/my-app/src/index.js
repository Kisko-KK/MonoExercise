import './index.css';
import App from './App';
import 'bootstrap/dist/css/bootstrap.min.css';

import * as React from "react";
import { createRoot } from "react-dom/client";
import { createBrowserRouter, RouterProvider,} from "react-router-dom";
import AddCountyForm from './components/AddCountyForm';
import EditCountyForm from './components/EditCountyForm';

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />
  },
  {
    path: "/add",
    element: <AddCountyForm />
  },
  {
    path: "/edit/:id",
    element: <EditCountyForm />
  }
]);

createRoot(document.getElementById("root")).render(
  <RouterProvider router={router} />
);



