import React, { useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import Table from "@material-ui/core/Table";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableContainer from "@material-ui/core/TableContainer";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import Paper from "@material-ui/core/Paper";
import SearchBar from "material-ui-search-bar";
import axios from "axios";

const useStyles = makeStyles({
  table: {
    minWidth: 650,
  },
});
  

export default function BasicTable() {
  const [originalRows, setOriginalRows] = useState([]);
  const [rows, setRows] = useState(originalRows);
  const [searched, setSearched] = useState("");
  const classes = useStyles();

  axios
  .get("https://localhost:7260/api/Shift")
  .then((res) => {
    console.log('hey')
  })
  .catch((err) => console.log(err));

  const requestSearch = (searchedVal) => {
    const filteredRows = originalRows.filter((row) => {
      return row.Department.toLowerCase().includes(searchedVal.toLowerCase());
    });
    setRows(filteredRows);
  };

  const cancelSearch = () => {
    setSearched("");
    requestSearch(searched);
  };

  return (
    <>
      <Paper>
        <SearchBar
          value={searched}
          onChange={(searchVal) => requestSearch(searchVal)}
          onCancelSearch={() => cancelSearch()}
        />
        <TableContainer>
          <Table className={classes.table} aria-label="simple table">
            <TableHead>
              <TableRow>
                <TableCell>Food (100g serving)</TableCell>
                <TableCell align="right">Department</TableCell>
                <TableCell align="right">Email</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {rows.map((row) => (
                <TableRow key={row.name}>
                  <TableCell component="th" scope="row">
                    {row.name}
                  </TableCell>
                  <TableCell align="right">{row.Department}</TableCell>
                  <TableCell align="right">{row.Email}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </TableContainer>
      </Paper>
      <br />
    </>
  );
}
