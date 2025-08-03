import React from 'react';

function OfficeSpace() {
  const officeList = [
    { name: 'DBS', rent: 50000, address: 'Chennai' },
    { name: 'Cognizant', rent: 75000, address: 'Bengaluru' },
    { name: 'The Executive Centre', rent: 59000, address: 'Mumbai' }
  ];

  return (
    <div>
      <h1>Office Space, at Affordable Range</h1>

      <img
        src="https://images.unsplash.com/photo-1556761175-5973dc0f32e7?w=800"
        alt="Modern office space"
        width="400px"
      />

      {officeList.map((office, index) => (
        <div key={index} style={{ marginTop: '20px' }}>
          <h3>Name: {office.name}</h3>

          <h4 style={{ color: office.rent <= 60000 ? 'red' : 'green' }}>
            Rent: Rs. {office.rent}
          </h4>
          <p>Address: {office.address}</p>
        </div>
      ))}
    </div>
  );
}

export default OfficeSpace;