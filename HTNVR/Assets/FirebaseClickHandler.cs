namespace FirebaseTest {
    #region Dependencies

    using Firebase;
    using Firebase.Database;
    using Firebase.Unity.Editor;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    public class FirebaseClickHandler : MonoBehaviour {
        public GameObject clickCube;

        [SerializeField] private Text _counterText;
    //    private int _count = -1;

        private float x = 0.3f;
       private float y = 0.3f;
        private float z = 0.3f;

        //Rotational Variables
        private float xrot = 0;
        private float yrot = 0;
        private float zrot = 0;




        private Vector3 size = new Vector3(0.3f, 0.3f, 0.3f);
        private DatabaseReference _counterRef;

        private DatabaseReference xref;
        private DatabaseReference yref;
        private DatabaseReference zref;


        private DatabaseReference xrefrot;
        private DatabaseReference yrefrot;
        private DatabaseReference zrefrot;



        private void Awake() {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(
                "https://hacknorth-58813.firebaseio.com/");


        // _counterRef = FirebaseDatabase.DefaultInstance.GetReference("counter");

            xref = FirebaseDatabase.DefaultInstance.GetReference("x");
            yref = FirebaseDatabase.DefaultInstance.GetReference("y");
            zref = FirebaseDatabase.DefaultInstance.GetReference("z");

            xrefrot = FirebaseDatabase.DefaultInstance.GetReference("/mobile_orient/mobile/LR");
            yrefrot = FirebaseDatabase.DefaultInstance.GetReference("/mobile_orient/mobile/DIR");
            zrefrot = FirebaseDatabase.DefaultInstance.GetReference("/mobile_orient/mobile/FB");

            //  _counterRef.ValueChanged += OnCountUpdated;

             xref.ValueChanged += OnCountUpdateX;
             yref.ValueChanged += OnCountUpdateY;
             zref.ValueChanged += OnCountUpdateZ;

            xrefrot.ValueChanged += OnCountUpdateRotX;
            yrefrot.ValueChanged += OnCountUpdateRotY;
            zrefrot.ValueChanged += OnCountUpdateRotZ;
        }

        private void Update() {
            //    _counterText.text = _count.ToString();
          //  Debug.Log("AYYYLMAO " + x + "," + y + "," + z);

            Debug.Log("ROTATION " + xrot + "," + yrot + "," + zrot);
            //   clickCube.transform.localScale = new Vector3(x, y, z);
     

            clickCube.transform.eulerAngles = new Vector3(xrot, -yrot, zrot);

        }

        private void OnCountUpdateX(object sender, ValueChangedEventArgs e) {

            if (e.DatabaseError != null) {
                Debug.LogError(e.DatabaseError.Message);
                return;
            }

            if (e.Snapshot == null || e.Snapshot.Value == null) {
            //    _count = 0;
             //   clickCube.transform.localScale = new Vector3(2,2,2);

                x = 0;
                Debug.Log("NULL!");
            } else {
           //     _count = int.Parse(e.Snapshot.Value.ToString());
                x = float.Parse(e.Snapshot.Value.ToString());
                // throw new System.NotImplementedException();
                //   _counterRef.SetValueAsync(_count);
                xref.SetValueAsync(x);
            //    Debug.Log("Coordinates: " + x +"," + y + "," + z);
            }

        }


        private void OnCountUpdateY(object sender, ValueChangedEventArgs e) {

            if (e.DatabaseError != null) {
                Debug.LogError(e.DatabaseError.Message);
                return;
            }

            if (e.Snapshot == null || e.Snapshot.Value == null) {
                //    _count = 0;
               // clickCube.transform.localScale = new Vector3(2, 2, 2);

                z = 0;
                Debug.Log("NULL!");
            } else {
                //     _count = int.Parse(e.Snapshot.Value.ToString());
                y = float.Parse(e.Snapshot.Value.ToString());

                // throw new System.NotImplementedException();
             //      _counterRef.SetValueAsync(_count);
                yref.SetValueAsync(y);

              //  Debug.Log("Coordinates: " + x + "," + y + "," + z);

            }

        }

        private void OnCountUpdateZ(object sender, ValueChangedEventArgs e) {

            if (e.DatabaseError != null) {
                Debug.LogError(e.DatabaseError.Message);
                return;
            }

            if (e.Snapshot == null || e.Snapshot.Value == null) {
                //    _count = 0;
             //   clickCube.transform.localScale = new Vector3(1, 1, 1);

                z = 0;
                Debug.Log("NULL!");

            } else {
                //     _count = int.Parse(e.Snapshot.Value.ToString());

                z = float.Parse(e.Snapshot.Value.ToString());

                // throw new System.NotImplementedException();
                //   _counterRef.SetValueAsync(_count);
                zref.SetValueAsync(z);

             //   Debug.Log("Coordinates: " + x + "," + y + "," + z);

            }

        }


        //Rotational Coodinates
        private void OnCountUpdateRotX(object sender, ValueChangedEventArgs e) {

            if (e.DatabaseError != null) {
                Debug.LogError(e.DatabaseError.Message);
                return;
            }

            if (e.Snapshot == null || e.Snapshot.Value == null) {
                //    _count = 0;
                //clickCube.transform.localScale = new Vector3(2, 2, 2);

                xrot = 0;
                Debug.Log("NULL!");
            } else {
                xrot = float.Parse(e.Snapshot.Value.ToString());
                // throw new System.NotImplementedException();
             //   xrefrot.SetValueAsync(xrot);
               
            }

        }


        private void OnCountUpdateRotY(object sender, ValueChangedEventArgs e) {

            if (e.DatabaseError != null) {
                Debug.LogError(e.DatabaseError.Message);
                return;
            }

            if (e.Snapshot == null || e.Snapshot.Value == null) {
                //    _count = 0;
               // clickCube.transform.localScale = new Vector3(2, 2, 2);

                yrot = 0;
                Debug.Log("NULL!");
            } else {
                yrot = float.Parse(e.Snapshot.Value.ToString());

            //    yrefrot.SetValueAsync(yrot);


            }

        }

        private void OnCountUpdateRotZ(object sender, ValueChangedEventArgs e) {

            if (e.DatabaseError != null) {
                Debug.LogError(e.DatabaseError.Message);
                return;
            }

            if (e.Snapshot == null || e.Snapshot.Value == null) {
                //    _count = 0;
              //  clickCube.transform.localScale = new Vector3(1, 1, 1);

                zrot = 0;
                Debug.Log("NULL!");

            } else {
                //     _count = int.Parse(e.Snapshot.Value.ToString());

                zrot = float.Parse(e.Snapshot.Value.ToString());
               // zrefrot.SetValueAsync(zrot);

            }

        }

        //End Rot Coordinates

    }
}


       
    
