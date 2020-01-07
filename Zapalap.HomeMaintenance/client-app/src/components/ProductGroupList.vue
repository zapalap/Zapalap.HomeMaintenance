<template>
  <div class="q-pa-md q-gutter-md row items-start">
    <div
      v-for="group in this.productGroups"
      :key="group.id"
    >
      <q-card class="bg-secondary text-white">
        <q-card-section class="text-h6">{{group.name}}</q-card-section>
        <q-card-section>{{group.description}}</q-card-section>
        <q-card-actions>
          <q-btn
            flat
            @click="deleteGroup(group.id)"
            label="delete"
          />
        </q-card-actions>
      </q-card>
    </div>
    <div>
      <q-btn
        round
        color="secondary"
        label="+"
        class="self-center"
        @click="dialogIsShown = true"
      />
    </div>

    <q-dialog v-model="dialogIsShown">
      <q-card>
        <q-card-section>
          <q-form
            @submit="createGroup"
            class="q-gutter-md"
          >

            <q-input
              filled
              v-model="groupToCreate.name"
              label="Group name"
              lazy-rules
              :rules="[val => val && val.length > 0] || 'Please provide name'"
            ></q-input>

            <q-input
              filled
              v-model="groupToCreate.description"
              label="Some nice description"
              lazy-rules
              :rules="[val => val && val.length > 0] || 'Please provide a description'"
            ></q-input>

            <q-card-section class="q-gutter-md">
              <q-btn
                label="Save"
                type="submit"
                color="primary"
                v-close-popup
              />
              <q-btn
                label="Cancel"
                color="primary"
                v-close-popup
              />
            </q-card-section>
          </q-form>
        </q-card-section>
      </q-card>
    </q-dialog>

  </div>
</template>

<script>
export default {
  name: 'ProductGroupList',
  data () {
    return {
      productGroups: [],
      dialogIsShown: false,
      groupToCreate: { name: null, description: null }
    }
  },
  methods: {
    fetchGroups () {
      this.$axios
        .get('api/productGroups')
        .then(response => (this.productGroups = response.data))
    },
    createGroup () {
      this.$axios
        .post('api/productGroups', { 'name': this.groupToCreate.name, 'description': this.groupToCreate.description })
        .then(_ => {
          this.groupToCreate.name = null
          this.groupToCreate.description = null
          this.fetchGroups()
        })
    },
    deleteGroup (groupId) {
      this.$axios
        .delete(`api/productGroups/${groupId}`)
        .then(_ => this.fetchGroups())
    }
  },
  mounted () {
    this.fetchGroups()
  }
}
</script>
