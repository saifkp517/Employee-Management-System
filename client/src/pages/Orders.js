import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Title from './Title';

// Generate Order Data
function createData(id, date, name, note, days) {
  return { id, date, name, note, days};
}

const rows = [
  createData(
    0,
    '16 Mar, 2019',
    'Elvis Presley',
    'Needed a Break!',
    2,
  ),
  createData(
    1,
    '16 Mar, 2019',
    'Paul McCartney',
    'Cuz Why Not?',
    1,
  ),
  createData(
    3,
    '16 Mar, 2019',
    'Michael Jackson',
    'Are we Human?',
    3,
  ),
  createData(
    4,
    '15 Mar, 2019',
    'Bruce Springsteen',
    'I am retired!',
    12,
  ),
];

export default function Orders() {
  return (
    <React.Fragment>
      <Title>Absentee Notes</Title>
      <Table size="small">
        <TableHead>
          <TableRow>
            <TableCell>Date</TableCell>
            <TableCell>Name</TableCell>
            <TableCell>Note</TableCell>
            <TableCell align="right">Days</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow key={row.id}>
              <TableCell>{row.date}</TableCell>
              <TableCell>{row.name}</TableCell>
              <TableCell>{row.note}</TableCell>
              <TableCell align="right">{row.days}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </React.Fragment>
  );
}