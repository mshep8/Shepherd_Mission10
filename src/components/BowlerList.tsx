/*
Mary Catherine Shepherd
IS 413
Mission 10

This component retrieves bowler data from the ASP.NET API
and displays it in a table.
*/

import { useEffect, useState } from "react";

type Bowler = {
    bowlerName: string;
    teamName: string;
    address: string;
    city: string;
    state: string;
    zip: string;
    phoneNumber: string;
};

function BowlerList() {

  // store the bowler list
    const [bowlers, setBowlers] = useState<Bowler[]>([]);

    // run once when component loads
    useEffect(() => {
        const fetchBowlers = async () => {
        const response = await fetch(
            "http://localhost:5008/Bowling/GetBowlers"
        );

        const data = await response.json();

        setBowlers(data);
        };

        fetchBowlers();
    }, []);

    return (
        <div>
        <table>
            <thead>
            <tr>
                <th>Bowler Name</th>
                <th>Team Name</th>
                <th>Address</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
                <th>Phone Number</th>
            </tr>
            </thead>

            <tbody>
            {bowlers.map((b, index) => (
                <tr key={index}>
                <td>{b.bowlerName}</td>
                <td>{b.teamName}</td>
                <td>{b.address}</td>
                <td>{b.city}</td>
                <td>{b.state}</td>
                <td>{b.zip}</td>
                <td>{b.phoneNumber}</td>
                </tr>
            ))}
            </tbody>
        </table>
        </div>
    );
}

export default BowlerList;