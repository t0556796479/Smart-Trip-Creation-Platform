import { Provider } from "react-redux";
import { store } from "./redux/store";
import InitializeAuth from "./auth/initializeAuth";
import { router } from "./routes/router";
import { RouterProvider } from "react-router-dom";

function App() {
  return (
    <div className="App">
      <Provider store={store}>
        <InitializeAuth>
          <RouterProvider router={router} />
        </InitializeAuth>
      </Provider>
    </div>
  );
}

export default App;
