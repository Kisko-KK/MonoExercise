import React from "react";

const Button = ({ onClick, text }) => {
  return <button className="my-2" onClick={onClick}>{text}</button>;
};

export default Button;