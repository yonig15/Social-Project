import React, { useState } from "react";
import { Routes, Route } from "react-router-dom";
import { ThemeContext } from "./context/theme.context";
import { RollsStatus } from "./context/rollsStatus";
import { useAuth0 } from "@auth0/auth0-react";
import "./App.css";
import { TopNavbar } from "./components/Navbar/topNavbar.component";
import { BottomNavbar } from "./components/Navbar/bottomNavbar.component";
import { AllUserSidebar } from "./components/Navbar/allUserSidebar";
import {
  AboutPage,
  ContactUsPage,
  HomePage,
  RegisterPage,
  RegisterTypeFormPage,
} from "./pages/page.index";

function App() {
  const { isAuthenticated, isLoading } = useAuth0();
  const [theme, setTheme] = useState(true);
  const [role, setRole] = useState(true);
  if (!isLoading) {
    if (isAuthenticated) {
      return (
        <ThemeContext.Provider value={{ theme, setTheme }}>
          <RollsStatus.Provider value={{ role, setRole }}>
            <div
              className={`App--${
                theme ? "Accessibility" : "CancelAccessibility"
              }`}
            >
              <header>
                <TopNavbar />
              </header>
              <div className="App--AllUserSidebar">
                <AllUserSidebar />
              </div>
              <div className="App--Routes">
                <Routes>
                  <Route path="/" element={<HomePage />}></Route>
                  <Route path="/about" element={<AboutPage />}></Route>
                  <Route path="/contactUs" element={<ContactUsPage />}></Route>
                  <Route path="/register" element={<RegisterPage />}></Route>
                  <Route
                    path="registerTypeForm"
                    element={<RegisterTypeFormPage />}
                  ></Route>
                </Routes>
              </div>
              <footer>
                <BottomNavbar />
              </footer>
            </div>
          </RollsStatus.Provider>
        </ThemeContext.Provider>
      );
    } else {
      return (
        <ThemeContext.Provider value={{ theme, setTheme }}>
          <RollsStatus.Provider value={{ role, setRole }}>
            <div
              className={`App--${
                theme ? "Accessibility" : "CancelAccessibility"
              }`}
            >
              <header>
                <TopNavbar />
              </header>
              <div className="App--AllUserSidebar">
                <AllUserSidebar />
              </div>
              <div className="App--Routes">
                <Routes>
                  <Route path="/" element={<HomePage />}></Route>
                  <Route path="/about" element={<AboutPage />}></Route>
                  <Route path="/contactUs" element={<ContactUsPage />}></Route>
                  <Route path="/register" element={<RegisterPage />}></Route>
                  <Route
                    path="registerTypeForm"
                    element={<RegisterTypeFormPage />}
                  ></Route>
                </Routes>
              </div>
              <footer>
                <BottomNavbar />
              </footer>
            </div>
          </RollsStatus.Provider>
        </ThemeContext.Provider>
      );
    }
  } else {
    return <h1>loading</h1>;
  }
}

export default App;
