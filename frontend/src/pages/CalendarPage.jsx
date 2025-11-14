import React, { useState } from "react";
import "./Calendar.css"; // make sure this file exists in the same folder

export default function CalendarPage() {
  const [currentDate, setCurrentDate] = useState(new Date());

  const monthName = currentDate.toLocaleDateString("en-US", {
    month: "long",
    year: "numeric",
  });

  const daysInMonth = new Date(
    currentDate.getFullYear(),
    currentDate.getMonth() + 1,
    0
  ).getDate();

  const firstDayIndex = new Date(
    currentDate.getFullYear(),
    currentDate.getMonth(),
    1
  ).getDay();

  const prevMonth = () => {
    setCurrentDate(
      new Date(currentDate.getFullYear(), currentDate.getMonth() - 1, 1)
    );
  };

  const nextMonth = () => {
    setCurrentDate(
      new Date(currentDate.getFullYear(), currentDate.getMonth() + 1, 1)
    );
  };

  // Build calendar days
  const daysArray = [];
  for (let i = 0; i < firstDayIndex; i++) daysArray.push(""); // leading empty cells
  for (let d = 1; d <= daysInMonth; d++) daysArray.push(d);

  return (
    <div className="calendar-page-container">
      <h1 className="calendar-title">Calendar</h1>

      <div className="month-controls">
        <button className="calendar-nav-button" onClick={prevMonth}>
          ←
        </button>

        <h2>{monthName}</h2>

        <button className="calendar-nav-button" onClick={nextMonth}>
          →
        </button>
      </div>

      <div className="calendar-grid-wrapper">
        <div className="calendar-grid">
          {/* Day headers */}
          {["SUN", "MON", "TUES", "WED", "THURS", "FRI", "SAT"].map((day) => (
            <div key={day} className="day-header">
              {day}
            </div>
          ))}

          {/* Calendar days */}
          {daysArray.map((day, index) => (
            <div key={index} className="day-cell">
              {day}
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}
