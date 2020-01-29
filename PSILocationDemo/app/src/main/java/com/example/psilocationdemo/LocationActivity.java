package com.example.psilocationdemo;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.drawable.Drawable;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationManager;
import android.os.Bundle;
import android.os.Looper;
import android.preference.PreferenceManager;
import android.provider.Settings;
import android.provider.Telephony;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.Magnifier;
import android.widget.SearchView;
import android.widget.TextView;
import android.widget.Toast;
import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationCallback;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationResult;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.BitmapDescriptor;
import com.google.android.gms.maps.model.BitmapDescriptorFactory;
import com.google.android.gms.maps.model.CameraPosition;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

import java.io.IOException;
import java.util.List;
import java.util.Locale;


public class LocationActivity extends AppCompatActivity {

    private static final int PERMISSION_ID = 1000;
    FusedLocationProviderClient mFusedLocationClient;
    LocationRequest mLocationRequest;

    GoogleMap map;
    SupportMapFragment mapFragment;
    SearchView searchView;

    TextView txt_location;
    TextView txt_address;
    Button btn_update;
    Button btn_confirm;

    String email;
    String address;
    Location gpsLocation;
    double longitude=49.0982;
    double latitude=-122.7093;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_location);



        //Get passing value
        Intent intent = getIntent();
        email = intent.getStringExtra("EMAIL");

        //Init View
        // Toolbar toolbar=(Toolbar) findViewById(R.id.toolbar);
        //setSupportActionBar(toolbar);
        //getSupportActionBar().setTitle("PSI Location");
        txt_location = (TextView) findViewById(R.id.txt_location);
        txt_address = (TextView) findViewById(R.id.txt_address);
        btn_update = (Button)findViewById(R.id.btn_update);
        btn_confirm = (Button)findViewById(R.id.btn_confirm);

        mFusedLocationClient = LocationServices.getFusedLocationProviderClient(this);

        getLocation();

        // Init map fragment
        searchView = (SearchView) findViewById(R.id.sv_location);
        mapFragment = (SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map);  //use SuppoprtMapFragment for using in fragment instead of activity  MapFragment = activity   SupportMapFragment = fragment
        setSearchQuery();

        //Set event for button
        btn_update.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                refreshLocationData();
            }
        });

        btn_confirm.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                openFormActivity(v);
            }
        });

        //Toast.makeText(this, "create", Toast.LENGTH_SHORT).show();

    }

    public void openFormActivity(View view){
        Intent intent = new Intent(this,FormActivity.class);
        intent.putExtra("ADDRESS", address);
        intent.putExtra("EMAIL", email);
        startActivity(intent);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.top_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()){
            case R.id.item1:
                Toast.makeText(this, "item 1 ", Toast.LENGTH_SHORT).show();
            case R.id.item2:
                Toast.makeText(this, "item 2 ", Toast.LENGTH_SHORT).show();
            case R.id.item3:
                Toast.makeText(this, "item 3 ", Toast.LENGTH_SHORT).show();
        }
        return super.onOptionsItemSelected(item);
    }

    private void setSearchQuery(){
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                String location = searchView.getQuery().toString();
                List<Address> addressList = null;

                if(location != null || !location.equals("")){
                    Geocoder geocoder = new Geocoder(LocationActivity.this);
                    try {
                        addressList = geocoder.getFromLocationName(location,1);
                        Address queryAddress = addressList.get(0);
                        Location queryLocation = new Location("");
                        queryLocation.setLatitude(queryAddress.getLatitude());//your coords of course
                        queryLocation.setLongitude(queryAddress.getLongitude());
                        setLocation(queryLocation);
                    } catch (IOException e) {
                        e.printStackTrace();
                        Toast.makeText(getApplicationContext(), "search not found", Toast.LENGTH_LONG).show();
                    }
                }else{
                    Toast.makeText(getApplicationContext(), "Please enter a value.", Toast.LENGTH_LONG).show();
                }
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                return false;
            }
        });
    }

    @SuppressLint("MissingPermission")
    private void getLocation(){
        if (checkPermissions()) {
            //Toast.makeText(this, "permission checked", Toast.LENGTH_SHORT).show();
            if (isLocationEnabled()) {
                //Toast.makeText(this, "location enabled", Toast.LENGTH_SHORT).show();
                mFusedLocationClient.getLastLocation().addOnCompleteListener(
                        new OnCompleteListener<Location>() {
                            @Override
                            public void onComplete(@NonNull Task<Location> task) {
                                final Location location = task.getResult();
                                if (location == null) {
                                    requestNewLocationData();
                                } else {
                                    setLocation(location);
                                }
                            }
                        }
                );
            } else {
                Toast.makeText(this, "Turn on location", Toast.LENGTH_LONG).show();
                Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                startActivity(intent);
            }
        } else {
            requestPermissions();
        }
    }

    @SuppressLint("MissingPermission")
    private void requestNewLocationData() {
        mLocationRequest = new LocationRequest();
        mLocationRequest.setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY);
        mLocationRequest.setInterval(5000);
        mLocationRequest.setFastestInterval(3000);
        mLocationRequest.setNumUpdates(1);
        //mLocationRequest.setSmallestDisplacement(10);

        mFusedLocationClient = LocationServices.getFusedLocationProviderClient(this);
        mFusedLocationClient.requestLocationUpdates(
                mLocationRequest, mLocationCallback,
                Looper.myLooper()
        );
    }

    private void refreshLocationData(){
        mFusedLocationClient = LocationServices.getFusedLocationProviderClient(this);
        mFusedLocationClient.removeLocationUpdates(mLocationCallback);
        requestNewLocationData();
    }

    private LocationCallback mLocationCallback = new LocationCallback() {
        @Override
        public void onLocationResult(LocationResult locationResult) {
            Location mLastLocation = locationResult.getLastLocation();
            setLocation(mLastLocation);
        }
    };

    private boolean checkPermissions() {
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED &&
                ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            return true;
        }
        return false;
    }

    private void requestPermissions() {
        ActivityCompat.requestPermissions(
                this,
                new String[]{Manifest.permission.ACCESS_COARSE_LOCATION, Manifest.permission.ACCESS_FINE_LOCATION},
                PERMISSION_ID
        );
    }

    private boolean isLocationEnabled() {
        LocationManager locationManager = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
        return locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER) || locationManager.isProviderEnabled(
                LocationManager.NETWORK_PROVIDER
        );
    }

    private void setLocation(Location location){
        longitude = location.getLongitude();
        latitude = location.getLatitude();

        try{
            Geocoder geocoder = new Geocoder(LocationActivity.this, Locale.getDefault() );
            List<Address> addressList = geocoder.getFromLocation(latitude,longitude,1);

            txt_location.setText("Location: "
                    + String.valueOf(latitude)
                    +", "
                    +String.valueOf(longitude));
            txt_address.setText("Address: " + addressList.get(0).getAddressLine(0));

            gpsLocation = location;
            address = txt_location.getText().toString()+'\n'+txt_address.getText().toString();

            mapFragment.getMapAsync(new OnMapReadyCallback() {
                @Override
                public void onMapReady(GoogleMap mMap) {
                    map = mMap;
                    mMap.setMapType(GoogleMap.MAP_TYPE_NORMAL);

                    mMap.clear(); //clear old markers
                    LatLng latLng = new LatLng(latitude,longitude);
                    mMap.addMarker(new MarkerOptions().position(latLng).title(txt_location.getText().toString()).snippet(txt_address.getText().toString()));
                    mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng,15));
                }
            });

        }catch (IOException e){
            e.printStackTrace();
        }
    }

    @Override
    public void onRequestPermissionsResult(int requestCode, String[] permissions, int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode == PERMISSION_ID) {
            if (grantResults.length > 0 && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                getLocation();
            }
            else
            {
                txt_address.setText("");
                txt_location.setText("Access not granted");
            }
        }
    }

    @Override
    public void onResume(){
        super.onResume();
        if (checkPermissions()) {
            getLocation();
        }

    }

}
