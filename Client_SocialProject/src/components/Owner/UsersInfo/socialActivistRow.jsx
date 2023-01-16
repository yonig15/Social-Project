import React, { useState, useEffect } from "react";
import { getAllSA_Rows } from "../../../services/allGetServices";

export const SocialActivistRow = () => {
  const [AllSARows, setAllSARows] = useState([]);

  const getSA_DB = async () => {
    let result = await getAllSA_Rows();
    setAllSARows(result);
  };

  useEffect(() => {
    getSA_DB();
  }, []);

  return (
    <>
      {AllSARows.length > 0 ? (
        AllSARows.map((item) => {
          let {
            FirstName,
            LastName,
            Email,
            Address,
            Phone_Number,
            Money_Status,
            Image_URL,
            Register_Time,
          } = item;
          return (
            <tr>
              <td>{FirstName}</td>
              <td>{LastName}</td>
              <td>{Email}</td>
              <td>{Address}</td>
              <td>{Phone_Number}</td>
              <td>{Money_Status}</td>
              <td>{Image_URL}</td>
              <td>{Register_Time}</td>
            </tr>
          );
        })
      ) : (
        <h4>There are no Social Activist</h4>
      )}
    </>
  );
};
