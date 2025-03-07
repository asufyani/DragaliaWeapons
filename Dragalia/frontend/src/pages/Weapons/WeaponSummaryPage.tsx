import React, { useEffect, useState } from 'react';
import {
  AccountWeaponData,
  ElementData,
  WeaponSeriesData,
  WeaponTypeData,
} from '../../api/DataInterfaces';
import { PrivateApi } from '../../api/PrivateData';
import { PublicApi } from '../../api/PublicData';
import { useAuth } from '../Auth/Auth';
import { LoadingText } from '../Loading';
import { Page } from '../Page';
import { WeaponSummaryList } from './WeaponSummaryList';

export const WeaponSummaryPage = () => {
  const { getAccessToken } = useAuth();
  const [weapons, setWeapons] = useState<AccountWeaponData[] | null>(null);
  const [weaponsLoading, setWeaponsLoading] = useState(true);

  const [elements, setElements] = useState<ElementData[]>([]);
  const [weaponSeries, setWeaponSeries] = useState<WeaponSeriesData[]>([]);
  const [weaponTypes, setWeaponTypes] = useState<WeaponTypeData[]>([]);

  useEffect(() => {
    let cancelled = false;
    const doGetPublicData = async () => {
      const api = new PublicApi();
      const elementData = await api.getElements();
      const weaponSeriesData = await api.getWeaponSeries();
      const weaponTypeData = await api.getWeaponTypes();
      if (!cancelled) {
        setElements(elementData.filter((e) => e.element !== 'None'));
        setWeaponSeries(weaponSeriesData.reverse());
        setWeaponTypes(weaponTypeData);
      }
    };
    const doGetWeapons = async () => {
      const token = await getAccessToken();
      const api = new PrivateApi(token);
      const weaponData = await api.getWeapons();
      if (!cancelled) {
        setWeapons(weaponData);
        setWeaponsLoading(false);
      }
    };
    doGetPublicData();
    doGetWeapons();
    return () => {
      cancelled = true;
    };
  }, [getAccessToken]);

  return (
    <Page title="Weapon Summary">
      {weaponsLoading ? (
        <LoadingText />
      ) : (
        <WeaponSummaryList
          data={weapons || []}
          elements={elements}
          weaponSeries={weaponSeries}
          weaponTypes={weaponTypes}
        />
      )}
    </Page>
  );
};
