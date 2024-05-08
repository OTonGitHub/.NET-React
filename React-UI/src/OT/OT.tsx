import './OT.css';

export interface OTi {
  NID: string;
  name: string;
  currency: string;
  price: number;
}

interface Props {
  OT: OTi;
}

export default function OTCard({ OT }: Readonly<Props>) {
  return (
    <div className='ot-card'>
      <div className='image'>
        <img
          src='https://source.unsplash.com/psFIFnVKIb4'
          alt='profile'
          width='400'
        />
      </div>
      <div className='info'>
        <ul>
          <li>NID: {OT.NID}</li>
          <li>Name: {OT.name}</li>
          <li>
            Price: {OT.currency} {OT.price}
          </li>
        </ul>
      </div>
    </div>
  );
}
